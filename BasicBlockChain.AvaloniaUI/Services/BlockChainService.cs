// BlockChainService.cs
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading;
using BasicBlockChain.Core;
using BasicBlockChain.AvaloniaUI.Models;

namespace BasicBlockChain.AvaloniaUI.Services
{
    public class BlockChainService
    {
        private BlockChain? _nullCoin; // Made nullable
        private string _currentFile = string.Empty; // Initialized

        public string MinerName { get; set; } = "DefaultMiner"; // Default miner name

        private const string BlockChainFile = "blockchain.json";
        private const string BlockChainLock = "blockchain.lock";

        public BlockChainService()
        {
            // _nullCoin is initialized in InitBlockChain or if that fails, a new one is created.
            // No direct initialization here to avoid overwriting loaded data immediately.
            // Consider calling InitBlockChain here if appropriate for application flow.
        }

        public BlockChain? GetBlockChain() // Return type made nullable
        {
            return _nullCoin;
        }

        public void InitBlockChain(string basePath = null)
        {
            string pathFile;
            string pathLock;

            if (string.IsNullOrEmpty(basePath))
            {
                basePath = Environment.CurrentDirectory;
            }
            ArgumentNullException.ThrowIfNull(basePath); // Ensure basePath is not null

            string finalBasePath = basePath; // Use a new variable to satisfy the analyzer
            pathFile = Path.Combine(finalBasePath, BlockChainFile);
            pathLock = Path.Combine(finalBasePath, BlockChainLock);
            _currentFile = pathFile;

            if (File.Exists(pathLock))
            {
                // Handle locked file scenario - for now, we'll just wait a bit and retry or throw.
                // In a real app, this might involve more sophisticated retry logic or user notification.
                Console.WriteLine("Lock file exists. Waiting or implement retry logic.");
                // For simplicity, we'll just proceed, but a real app needs robust handling.
                // This could be a point of failure if another instance is actively writing.
            }

            if (File.Exists(pathFile))
            {
                try
                {
                    string contentBlockChainFile = File.ReadAllText(pathFile);
                    if (!string.IsNullOrWhiteSpace(contentBlockChainFile))
                    {
                        SerializableBlockChain? loadedData = JsonSerializer.Deserialize<SerializableBlockChain>(contentBlockChainFile);
                        if (loadedData != null && loadedData.BlockChain != null)
                        {
                            _nullCoin = loadedData.BlockChain;
                            MinerName = loadedData.Miner ?? MinerName; 
                        }
                        else
                        {
                            // File content was not valid or blockchain part was null, initialize new
                            _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1));
                            // If loadedData is not null but BlockChain is, we might still want the MinerName
                            if (loadedData != null) MinerName = loadedData.Miner ?? MinerName;
                        }
                    }
                    else
                    {
                        // File was empty, initialize new
                        _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1));
                    }
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"Error deserializing blockchain: {jsonEx.Message}");
                    // Decide how to handle corrupt file - e.g., backup and create new, or throw
                    _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1)); // Initialize new on error
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"IO Error reading blockchain: {ioEx.Message}");
                    // Decide how to handle - e.g., throw, or try to initialize new
                    _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1)); // Initialize new on error
                }
            }
            else
            {
                // File does not exist, initialize a new blockchain
                _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1));
                SaveBlockChain(); // Save the new blockchain immediately
            }
        }

        public void SaveBlockChain()
        {
            // Ensure _nullCoin is not null before saving.
            // This should be guaranteed by InitBlockChain creating a new one if loading fails.
            if (_nullCoin == null)
            {
                Console.WriteLine("Error: Blockchain is null, cannot save. Initializing a new one.");
                _nullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1));
                // Attempt to set _currentFile if it's somehow still empty, though InitBlockChain should handle this.
                if (string.IsNullOrEmpty(_currentFile))
                {
                     _currentFile = Path.Combine(Environment.CurrentDirectory, BlockChainFile);
                }
            }
            
            string pathLock = Path.ChangeExtension(_currentFile, ".lock");
            // Ensure _currentFile is actually set before using Path.ChangeExtension
            if (string.IsNullOrEmpty(_currentFile)) 
            {
                // This is a fallback, ideally _currentFile is always set by InitBlockChain
                _currentFile = Path.Combine(Environment.CurrentDirectory, BlockChainFile);
                pathLock = Path.Combine(Environment.CurrentDirectory, BlockChainLock);
                Console.WriteLine($"Warning: _currentFile was empty during SaveBlockChain. Defaulting to: {_currentFile}");
            } else {
                pathLock = Path.ChangeExtension(_currentFile, ".lock");
            }

            try
            {
                // Create/touch lock file
                using (FileStream lockFs = new FileStream(pathLock, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    // Lock file created
                }

                SerializableBlockChain toSave = new SerializableBlockChain
                {
                    BlockChain = _nullCoin,
                    Miner = MinerName
                };

                string contentBlockChainFile = JsonSerializer.Serialize(toSave, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_currentFile, contentBlockChainFile);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"IO Error saving blockchain: {ioEx.Message}");
                // Handle error (e.g., retry, log, notify user)
            }
            finally
            {
                if (File.Exists(pathLock))
                {
                    File.Delete(pathLock);
                }
            }
        }
    }
}
