using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using System.Text.Json;
using static System.Console;

var _mqttClient = new MqttFactory().CreateManagedMqttClient();

var clientId = "sensor1";
var server = "localhost";
var builder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(server);
var options = new ManagedMqttClientOptionsBuilder()
                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                    .WithClientOptions(builder.Build())
                    .Build();
// Set up handlers
_mqttClient.ConnectedAsync += _mqttClient_ConnectedAsync;
_mqttClient.DisconnectedAsync += _mqttClient_DisconnectedAsync;
_mqttClient.ConnectingFailedAsync += _mqttClient_ConnectingFailedAsync;

WriteLine($"{clientId} 連線到 MQTT Broker ({server}) ....");
await _mqttClient.StartAsync(options);

while (true)
{
    WriteLine("請輸入Topic, Like(home/temperature/sensor-1):");
    var topic = ReadLine();
    if (string.IsNullOrWhiteSpace(topic))
        topic = $"home/temperature/{clientId}";
    WriteLine("請輸入要傳送的訊息:");
    var message = ReadLine();
    if (!string.IsNullOrWhiteSpace(message))
    {
        var json = JsonSerializer.Serialize(new { message, sent = DateTime.UtcNow });
        await _mqttClient.EnqueueAsync(topic, json);

        // Wait until the queue is fully processed.
        SpinWait.SpinUntil(() => _mqttClient.PendingApplicationMessagesCount == 0, 10000);
        WriteLine($"Pending messages = {_mqttClient.PendingApplicationMessagesCount}");
    }
    else
    {
        WriteLine("訊息不可為空，請重新輸入!");
    }
}
Task _mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
{
    WriteLine("Connected");
    return Task.CompletedTask;
};
Task _mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
{
    WriteLine("Disconnected");
    return Task.CompletedTask;
};
Task _mqttClient_ConnectingFailedAsync(ConnectingFailedEventArgs arg)
{
    WriteLine("Connection failed check network or broker!");
    return Task.CompletedTask;
}