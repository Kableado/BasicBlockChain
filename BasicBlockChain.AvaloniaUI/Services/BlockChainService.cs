using BasicBlockChain.Core;
using BasicBlockChain.AvaloniaUI.Models; // For BlockChainSaveData
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks; // For any async operations if desired, though original was sync

namespace BasicBlockChain.AvaloniaUI.Services
{
    public class BlockChainService
    {
        public BlockChain NullCoin { get; private set; }
        public string MinerName { get; set; } // To store/retrieve miner name

        private const string BlockChainFilePattern = "BlockChain.{0}.json";
        private const string BlockChainLockPattern = "BlockChain.{0}.lock";
        private int _currentFile = 0;
        private string _lockFilePath = string.Empty;

        public BlockChainService()
        {
            // MinerName could be loaded from settings or initialized here
            MinerName = string.Empty; 
            InitBlockChain();
        }

        private void InitBlockChain()
        {
            BlockChainSaveData? saveData = null; // Nullable for deserialized data

            // Determine current blockchain file and lock it
            string blockChainLockPath;
            do
            {
                blockChainLockPath = string.Format(BlockChainLockPattern, _currentFile);
                // Check if lock file exists and is held by another process (more robust lock needed for multi-instance)
                // For this migration, simple file existence is similar to original
                if (!File.Exists(blockChainLockPath)) 
                {
                    try 
                    {
                        File.WriteAllText(blockChainLockPath, "Locked by BasicBlockChain.AvaloniaUI");
                        _lockFilePath = blockChainLockPath; // Store for unlocking
                        break; 
                    } 
                    catch (IOException)
                    {
                        // File might have been created between check and write, try next
                    }
                }
                _currentFile++;
            } while (true);

            string blockChainFile = string.Format(BlockChainFilePattern, _currentFile);
            if (File.Exists(blockChainFile))
            {
                try
                {
                    string contentBlockChainFile = File.ReadAllText(blockChainFile);
                    // Ensure options are compatible if BlockChain/Transaction classes use specific attributes
                    saveData = JsonSerializer.Deserialize<BlockChainSaveData>(contentBlockChainFile);
                }
                catch (JsonException ex)
                {
                    // Handle deserialization error (e.g., log, notify user, start fresh)
                    Console.WriteLine($"Error deserializing blockchain: {ex.Message}");
                    saveData = null; 
                }
                catch (IOException ex)
                {
                     Console.WriteLine($"Error reading blockchain file: {ex.Message}");
                     saveData = null;
                }
            }

            if (saveData != null && saveData.BlockChain != null)
            {
                NullCoin = saveData.BlockChain;
                MinerName = saveData.Miner ?? string.Empty;
            }
            else
            {
                NullCoin = new BlockChain(genesisDate: new DateTime(2000, 1, 1), difficulty: 2);
                // MinerName remains as initialized or empty
            }
        }

        public void SaveBlockChain()
        {
            if (NullCoin == null) return;

            string blockChainFile = string.Format(BlockChainFilePattern, _currentFile);
            
            BlockChainSaveData saveData = new BlockChainSaveData
            {
                BlockChain = NullCoin,
                Miner = MinerName,
            };

            try
            {
                string strBlockChain = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(blockChainFile, strBlockChain);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error serializing blockchain: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing blockchain file: {ex.Message}");
            }
        }

        public void ReleaseLock()
        {
            if (!string.IsNullOrEmpty(_lockFilePath) && File.Exists(_lockFilePath))
            {
                try
                {
                    File.Delete(_lockFilePath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error releasing lock file: {ex.Message}");
                }
            }
        }
    }
}
