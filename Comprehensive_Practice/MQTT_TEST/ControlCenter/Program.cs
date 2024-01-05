using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using System.Text.Json;
using static System.Console;
using System.Text;
using MQTTnet.Packets;

var _mqttClient = new MqttFactory().CreateManagedMqttClient();

var clientId = "controlCenter";
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
_mqttClient.ApplicationMessageReceivedAsync += _mqttClient_ApplicationMessageReceivedAsync;

var topicFilters = new List<MqttTopicFilter> { new MqttTopicFilter { Topic = "home/temperature/#" } };
await _mqttClient.SubscribeAsync(topicFilters);

WriteLine($"{clientId} 連線到 MQTT Broker ({server}) ....");
await _mqttClient.StartAsync(options);
WriteLine("Press any key to stop receive message ...");
ReadKey();

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

Task _mqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
{
    var topic = arg?.ApplicationMessage?.Topic;
    var payloadText = Encoding.UTF8.GetString(
            arg?.ApplicationMessage?.Payload ?? Array.Empty<byte>());

    WriteLine($"Received: Topic:{topic}, Payload:{payloadText}");
    return Task.CompletedTask;
}