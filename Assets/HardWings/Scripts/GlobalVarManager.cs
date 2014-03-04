using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;

public class GlobalVarManager : MonoBehaviour {
    private static GlobalVarManager s_instance = null;

	const string muteKey = "Mute";
	private int muteValue = 0;

	const string scoreKey = "Score";
	private int scoreValue = 0;

    const string leaderBoard = "hardwings.rank";
	
	public static GlobalVarManager instance {
        get {
            if (null == s_instance) {
                s_instance = FindObjectOfType(typeof(GlobalVarManager)) as GlobalVarManager;
                if (null == s_instance) {
                    Debug.Log("Fail to get Manager Instance");
                }
            }
            return s_instance;
        }
    }
	
	public bool GetMuteValue(){
		if (muteValue==1) return true;
		else return false;
	}
	
	public void SetMuteValue(bool val){
		//Debug.Log("SetMuteValue:"+val);
		if (val) muteValue = 1;
		else muteValue = 0;
		SaveMuteFlag(muteValue);
	}
	
	public int LoadMuteFlag(){
		int flag = 0;
		if (PlayerPrefs.HasKey(muteKey)) {
			 flag = PlayerPrefs.GetInt(muteKey);
		}
		//Debug.Log("LoadMuteFlag:"+flag);
		return flag;
	}
	
	public void SaveMuteFlag(int flag){
		PlayerPrefs.SetInt(muteKey, flag);
		//Debug.Log("SaveMuteFlag:"+flag);
	}
	
	public int GetScoreValue(){
		return scoreValue;
	}
	
	public void SetScoreValue(int val){
		scoreValue = val;
		SaveScoreRecord(scoreValue);
	}

	public int LoadScoreRecord(){
		int score = 0;
		if (PlayerPrefs.HasKey(scoreKey)) {
			 score = PlayerPrefs.GetInt(scoreKey);
		}
		//Debug.Log("LoadScoreRecord:"+score);
		return score;
	}
	
	public void SaveScoreRecord(int score){
		//Debug.Log("SaveScoreRecord : " + score);
		PlayerPrefs.SetInt(scoreKey, score);
        ReportScore(leaderBoard, score);
	}

    void OnApplicationQuit() {
        s_instance = null;
    }
 
	void Awake () {
		DontDestroyOnLoad(this);
		muteValue = LoadMuteFlag();
		scoreValue = LoadScoreRecord();
		Social.localUser.Authenticate (HandleAuthenticated);
	}

	private void HandleAuthenticated (bool success) {
		if (success) {
			//Social.localUser.LoadFriends (HandleFriendsLoaded);
			//Social.LoadAchievements (HandleAchievementsLoaded);
			//Social.LoadAchievementDescriptions (HandleAchievementDescriptionsLoaded);
		}
	}

	private void HandleFriendsLoaded (bool success) {
		foreach (IUserProfile friend in Social.localUser.friends) {
		}
	}

	private void HandleAchievementsLoaded (IAchievement[] achievements) {
		foreach (IAchievement achievement in achievements) {
		}
	}

	private void HandleAchievementDescriptionsLoaded (IAchievementDescription[] achievementDescriptions) {
		foreach (IAchievementDescription achievementDescription in achievementDescriptions) {
		}
	}

	public void ReportProgress (string achievementId, double progress) {
		if (Social.localUser.authenticated) {
			Social.ReportProgress (achievementId, progress, HandleProgressReported);
		}
	}
	private void HandleProgressReported (bool success) {
	}

	public void ShowAchievements () {
		if (Social.localUser.authenticated) {
			Social.ShowAchievementsUI ();
		}
	}

	public void ReportScore (string leaderboardId, long score) {
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, leaderboardId, HandleScoreReported);
		}
	}
	public void HandleScoreReported (bool success) {
	}
	public void ShowLeaderboard () {
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI (); 
		}
	}

	void Start () {
	}
	
	void Update () {
	
	}
}
