// The following sample code uses modern ECMAScript 6 features 
// that aren't supported in Internet Explorer 11.
// To convert the sample for environments that do not support ECMAScript 6, 
// such as Internet Explorer 11, use a transpiler such as 
// Babel at http://babeljs.io/. 
//
// See Es5-chat.js for a Babel transpiled version of the following code:

$(document).ready(function () {
var recipientId = null;
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

    connection.on("ReceiveMessage", (user, message) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = user + ": " + message;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(err => console.error(err.toString()));

    document.getElementById("sendButton").addEventListener("click", event => {
    const sender = $('#userInput').text();
    const user = recipientId;
    const message = document.getElementById("messageInput").value;
        if (sender !== user) {
            connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
            connection.invoke("SendMessageMyself", message).catch(err => console.error(err.toString()));
        } else {
            connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
        }
   
    event.preventDefault();
    });

    $('a.btn').click(function () {
        recipientId = $(this).attr('id');
        var userName = $(this).text();
        $('p#recipient').text('You want to send a message to ' +userName);
    });
});