#R2=8M[0xD687730]
#R2=8M[R2+0x160]
#R2=8M[R2+0x10]
#R2=8M[R2+0x20+8*(n-1)]
#R2=R2+0x40
#M[R2] = 0x|xxxx 0410 xxxx

#[[[[main+D687730]+160]+10]+20]+40

import socket
import time
import binascii

def send_command(s, content):
    content += '\r\n' #important for the parser on the switch side
    s.sendall(content.encode())

def connect(nip,port=6000):
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect((nip, port))
    return s

def set_addr(s,addr,data):
    ed = data.to_bytes(2,'little')
    st = binascii.hexlify(ed).decode()
    send_command(s, f"pokeAbsolute {hex(addr)} 0x{st}")

def get_1st_offset(s,offset1 = 'D687730'):
    lengh = 5
    send_command(s, f"peekMain 0x{offset1} {lengh}")
    time.sleep(0.5) #give time to answer
    ofs = ''
    #return s.recv(11)
    for i in range(lengh):
        ofs = s.recv(2).decode() + ofs
    s.recv(2)
    #return ofs

    a = ofs
    if int(a, 16) == 0:
        return a
    
    #[[[[main+D687730]+160]+10]
    n=get_next_addr(s,a,0x160)
    n=get_next_addr(s,n,0x10)

    return n

def get_next_addr(s,offset_1st, offset_n, lengh=5):
    a=int(offset_1st,16) + offset_n
    send_command(s, f"peekAbsolute {hex(a)} {lengh}")
    time.sleep(0.1) #give time to answer
    ofs = ''
    for i in range(lengh):
        ofs = s.recv(2).decode() + ofs
    s.recv(2)
    return ofs

def get_item(s,n,bag_num = 1):
    a=int(n, 16)
    if a == 0:
        return -1

    if bag_num < 1:
        bag_num = 1
    if bag_num > 1200:
        bag_num = 1200
    
    #+0x20 + offset
    n=get_next_addr(s,n,0x20+8*(bag_num-1)) # 
    # num ~ 1-1200

    #+0x40
    item=get_next_addr(s,n,0x40,6)

    item_id = item[8:]
    item_state = item[4:8] # always 0410?
    item_cont = item[:4]

    return (int(item_id, 16), int(item_cont, 16),  item_state, int(n,16) + 0x40)

def set_item(s,n,bag_num,itemid = -1,cont = -1):
    item = get_item(s,n,bag_num)
    if item == -1:
        return
    if item[2] == '0410' or item[2] == '0400':
        set_addr(s,item[3]+2, 1040) #'0410'

        if itemid != -1:
            set_addr(s,item[3], itemid)
        if cont != -1:
            set_addr(s,item[3]+4, cont)
    else:
        print('cannt write item')
        return

s=connect("192.168.1.103")
send_command(s, f"pointerAll 0xD9674B8 0x60 0x10")
# getTitleID
# getBuildID
#getVersion
#pointer
#pointerAll
#pointerPeek/Poke
time.sleep(0.1) #give time to answer

r = s.recv(17)
print(r)

#n=get_1st_offset(s, "D687730")
#print(n)

#idx = 99
#item = get_item(s,n, idx)
#set_item(s,n, idx, 172,990)
#item = get_item(s,n, idx)
#print(item)