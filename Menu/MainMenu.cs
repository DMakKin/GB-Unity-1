using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DM;

public class MainMenu : BaseMenu
{
   #region New

    [SerializeField] private GameObject _mainPanale;

    [SerializeField] private ButtonUi _newGame;
    [SerializeField] private ButtonUi _continue;
    [SerializeField] private ButtonUi _options;
    [SerializeField] private ButtonUi _quit;

    private Player _player;
    
    private void Start()
    {      
        _newGame.GetText.text = LangManager.Instance.Text("MainMenuItems", "NewGame");
        _newGame.GetControl.onClick.AddListener(delegate
        {
            LoadNewGame(Main.Instance.Scenes.Game.SceneAsset.name);
        });

        _continue.GetText.text = LangManager.Instance.Text("MainMenuItems", "Continue");
        _continue.GetControl.onClick.AddListener(delegate
        {
            ContinueGame(Main.Instance.Scenes.Game.SceneAsset.name);
        });

        _options.GetText.text = LangManager.Instance.Text("MainMenuItems", "Options");

        _quit.GetText.text = LangManager.Instance.Text("MainMenuItems", "Quit");
        _quit.GetControl.onClick.AddListener(delegate
        {
            Interface.QuitGame();
        });
    }

    #endregion

    public override void Hide()
    {
        if (!IsShow) return;
        _mainPanale.gameObject.SetActive(false);
        //Clear(_elementsOfInterface);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _mainPanale.gameObject.SetActive(true);
        //var tempMenuItems = System.Enum.GetNames(typeof(MainMenuItems));
        //CreateMenu(tempMenuItems);
        IsShow = true;
    }

    private void ShowOptions()
    {
        Interface.Execute(InterfaceObject.OptionsMenu);
    }

    private void LoadNewGame(string lvl)
    {
        SceneManager.sceneLoaded += delegate { Main.Instance.InitGame(); };
        Interface.LoadSceneAsync(lvl);
    }

    private void ContinueGame(string lvl)
    {
        SceneManager.sceneLoaded += delegate { Main.Instance.InitGame(); };
        Interface.LoadSceneAsync(lvl);

        Player.itsContinue = true;
    }
}
