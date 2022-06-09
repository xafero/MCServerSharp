using MCServerSharp.Data.Utils;
using MCServerSharp.Events;
using MCServerSharp.Worlds;
using System;

namespace MCServerSharp
{
    public interface IServer : IDisposable
    {
        bool IsOperator(UUID uuid);

        IWorld FindWorld(string name);

        IEventsFactory EventsFactory { get; }

        string GameVersion { get; }

        string ServerIconBase64 { get; }

        int MaxPlayers { get; }

        int PlayersCount { get; }

        void LogError(string message);

        void Close();
    }
}