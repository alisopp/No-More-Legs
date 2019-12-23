using System.Collections;
using Interfaces;
using NoMoreLegs;
using NoMoreLegs.Winning;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestWinGame
    {
        private class WinCase : IGameWinListener
        {
            public bool WonGame = false;
            public void OnGameWin()
            {
                WonGame = true;
            }
        }
        
        static int[] values = new int[] { 2, 3};
        
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.


        [UnityTest]
        public IEnumerator TestWinGameWithEnumeratorPasses([ValueSource("values")] int value)
        {
            EditorSceneManager.LoadScene(value);
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            WinCase winCase = new WinCase();
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameManager.GetInstance().StartGame();
            yield return new WaitForEndOfFrame();
            WinningZone winningZone = GameObject.FindObjectOfType<WinningZone>();
            
            GameManager.GetInstance().AddGameWinListener(winCase);
            GameManager.GetInstance().CurrentPlayer.transform.position = winningZone.transform.position;
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(winCase.WonGame);
        }
    }
}
