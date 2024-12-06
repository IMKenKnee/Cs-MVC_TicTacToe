//Kenny Hedlund
//Chapter 10 - TicTacToe

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace TicTacToe
{
    public static class SessionExtensions
    {
        // Session storage om Json form
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Read data objections from session storage
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
