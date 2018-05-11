


public class Cowsay {

    public string Speak(string message) {

        var messageLength = message.Length;
        var paddedMessage = message.PadLeft(messageLength + 1).PadRight(messageLength + 2);
        var paddedMessageLength = paddedMessage.Length;

        var border = "<" + "-".Repeat(paddedMessageLength) + ">";
        var messageLine = "<" + paddedMessage + ">";

        var output = string.Format(@"
    {0} 
    {1}
    {0}
         \   ^__^ 
          \  (oo)\_______
             (__)\       )\/\\
                 ||----w |
                 ||     ||
        ", border, messageLine);

        return output;
    }
}