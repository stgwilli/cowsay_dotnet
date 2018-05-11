

using System.Linq;

public static class StringExtensions {

    public static string Repeat(this string input, int times) {
        return new string(Enumerable.Range(0, times).SelectMany(x => input).ToArray());
    }

    public static string Repeat(this char c, int times) {
        return new string(c, times);
    }
}