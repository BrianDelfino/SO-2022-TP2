var net = require('net');
const readline = require('readline-sync')

const server = net.createServer()       

server.on('connection',(socket)=>{              
    socket.on('data', data =>{
        console.log(""+ data)
        sendLine()
    })
    socket.on('close',()=>{
        console.log("Comunicacion finalizada")          
    })
    socket.on('error', (err)=>{
        console.log(err.message)
    })
    function sendLine(){                                   
        var line = readline.question('Escribir: ')  
        if (line == "0"){
            socket.end()
        }else{
            socket.write("Servidor dijo: " + line + "\n")      
        }
    
    }

})

const port = 5000

server.listen(port, ()=>{
    console.log("Servidor conectado en el", server.address().port)  
})