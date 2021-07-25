using UnityEngine.SceneManagement;
using Scream.UniMO;

class FlowController : TSingletonMonoBehavior<FlowController>
{
    public SceneData Data { get; private set; } = null;
    public void LoadScene(SceneIndex sceneToLoad, SceneData data)
    {
        SceneManager.LoadScene((int)sceneToLoad);
        Data = data;
    }
}


abstract class SceneData
{ }

class ResultData : SceneData
{
    public ResultData(string winner) => Winner = winner;
    public string Winner { get; private set; } = null;
}

