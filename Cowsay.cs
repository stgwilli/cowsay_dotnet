


public class Cowsay {

    public string Speak(string message, bool dead=false) {

        var messageLength = message.Length;
        var paddedMessage = message.PadLeft(messageLength + 1).PadRight(messageLength + 2);
        var paddedMessageLength = paddedMessage.Length;

        var border = "<" + "-".Repeat(paddedMessageLength) + ">";
        var messageLine = "<" + paddedMessage + ">";

        var output = string.Format(@"
    {0} 
    {1}
    {0}
         \  ^___^ 
          \ ({2} {2})\_______
            (___)\       )\/\\
                 ||----w |
                 ||     ||
        ", border, messageLine, dead ? 'x' : 'o');

        return output;
    }
}