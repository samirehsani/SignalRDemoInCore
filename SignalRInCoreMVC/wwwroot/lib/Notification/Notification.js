var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

//start connection
async function Start() {
    try {
        await connection.start();
        console.log('Connection started');
    } catch (err) {
        console.log(`Failed to connect ${err}`);
    }
}

// onclose try to connect again
connection.onclose(Start);

//Subscribe to category
function SubscribeToCategory(categoryName) {
    connection.invoke("SubscribeToCategory", categoryName).catch(function (err) {
        return console.error(err.toString());
    });
}

