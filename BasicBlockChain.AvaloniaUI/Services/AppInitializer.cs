using BasicBlockChain.AvaloniaUI.Services;
using System;
using System.IO; // Required for path operations if any are needed here

namespace BasicBlockChain.AvaloniaUI.Initialization // As per subtask spec
{
    public static class AppInitializer
    {
        public static BlockChainService? BlockChainServiceInstance { get; private set; }

        public static void Initialize()
        {
            // Instantiates the service, which calls InitBlockChain in its constructor
            BlockChainServiceInstance = new BlockChainService(); 
            
            // Register a handler for process exit to save and release lock
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private static void OnProcessExit(object? sender, EventArgs e)
        {
            BlockChainServiceInstance?.SaveBlockChain();
            BlockChainServiceInstance?.ReleaseLock();
        }
    }
}
