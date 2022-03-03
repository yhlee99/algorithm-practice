// Description: 알림(Alert)에 대한 번역이 실시간으로 바뀌는 걸 관찰하고 알림에 대한 Queue를 관리하는 Model

namespace Foo
{
    public class Alert : MonoBehaviour 
    {
        public GameObject tournamentInfoPanel;
        public Text tablesText;
        public Text blindsText;
        public Text blindTimerText;

        // alert
        public GameObject alertSpace;
        public Text alertText;

        // Cache
        private InfoData infoData;
        private TournamentAlertData alertData;

        // Const
        private const float SINGLE_ALERT_TIME = 5.0f;
        private const float MULTI_ALERT_TIME = 3.0f;

        private ConcurrentQueue<string> alertQueue = new ConcurrentQueue<string>();
        private CancellationTokenSource alertToken = new CancellationTokenSource();
        private int alertShowCount = 0;

        private void Awake()
        {
            TimerService.OnRemainTimer += HandleOnBlindRemainTimer;
            LocaizeService.OnLocalizeEvent += HandleOnLocalizeEvent;
        }

        private void OnDestroy()
        {
            TimerService.OnRemainTimer -= HandleOnBlindRemainTimer;
            LocaizeService.OnLocalizeEvent -= HandleOnLocalizeEvent;
        }

        // 번역 바뀐 이후 아래 Method Call
        private void HandleOnLocalizeEvent()
        {
            UpdateTournamentInfo(infoData);

            if (alertData != null)
            {
                CancelAlertQueue();
                EnqueueAlertQueue();

                for (int i = 0; i < alertShowCount; i++)
                {
                    string alreadyShowText;
                    alertQueue.TryDequeue(out alreadyShowText);
                }

                DequeueAlertQueue(alertToken.Token).Forget();
            }
        }

        public void SetTournamentInfo(TournamentSyncData data, bool isSync = false)
        {
            this.infoData = data;

            if (isSync == true)
            {
                tournamentInfoPanel.SetActive(true);
            }

            UpdateTournamentInfo(data);
            CreateTournamentTimer(data);
        }

        private void UpdateTournamentInfo(TournamentSyncData data)
        {
            tablesText.text = string.Format("{0}, {1}", 
            (string.Format(Logic.Localization.GetLocalizationValue(DefineService.LocalizationCategorize.Game, "DASHBOARD_TEXT_TABLE"), data.tables)),
            (string.Format(Logic.Localization.GetLocalizationValue(DefineService.LocalizationCategorize.Game, "DASHBOARD_TEXT_USERS"), data.players)));
        }

        private void CreateTournamentTimer(TournamentSyncData data)
        {
            if (data.blindRaiseIn > 0)
            {
                TimerService.Instance.Create(TimerType.BlindTimer, Logic.Util.ConvertMillisecondToSecond(data.blindRaiseIn), true);
            }
        }

        private void HandleOnBlindRemainTimer(TimerType type, float second)
        {
            if (type == TimerType.BlindTimer)
            {
                TimeSpan time = Logic.UniTaskDelay.FromSeconds(Mathf.Max(second, 0));

                blindTimerText.text = 
                string.Format("{0} ({1})",
                    string.Format(Logic.Localization.GetLocalizationValue(DefineService.LocalizationCategorize.Game, "DASHBOARD_TEXT_BLINDS"), 
                        $"{Logic.Util.FormatNumber(infoData.blinds.smallBlind.chips)}/{Logic.Util.FormatNumber(infoData.blinds.bigBlind.chips)}"),
                    (Logic.Util.FormatTimerMinuteSecondNoSpacing(time)));
            }
        }

        public async UniTask HandleOnTournamentAlert(TournamentAlertData data, CancellationToken cancellationToken)
        {
            this.alertData = data;

            EnqueueAlertQueue();
            
            alertShowCount = 0;
            await DequeueAlertQueue(alertToken.Token);
        }

        private void EnqueueAlertQueue()
        {
            if (alertData.isNewPlayer == true)
            {
                alertQueue.Enqueue(GetNewPlayerAlertText());
            }

            if (alertData.users.Count > 0)
            {
                foreach (var user in alertData.users)
                {
                    alertQueue.Enqueue(GetUsersAlertText(user));
                }
            }

            if (alertData.blind != null)
            {
                if (alertData.blind.smallBlind.chips != 0 && alertData.blind.bigBlind.chips != 0)
                {
                    alertQueue.Enqueue(GetBlindsAlertText(alertData.blind.smallBlind.chips, alertData.blind.bigBlind.chips));
                }
            }
        }

        private async UniTask DequeueAlertQueue(CancellationToken cancellationToken)
        {
            float showTime = (alertQueue.Count >= 2) ? MULTI_ALERT_TIME : SINGLE_ALERT_TIME;
            string targetText;

            while (alertQueue.TryDequeue(out targetText))
            {
                alertText.text = targetText;
                alertSpace.SetActive(true);

                await UniTask.Delay(Logic.UniTaskDelay.FromSeconds(showTime), cancellationToken: cancellationToken);

                alertSpace.SetActive(false);
                alertShowCount++;
            }
        }

        public void CancelAlertQueue()
        {
            alertToken.Cancel();

            alertQueue = new ConcurrentQueue<string>();
            alertToken = new CancellationTokenSource();
        }

        private string GetNewPlayerAlertText()
        {
            return "Foo1";
        }

        private string GetUsersAlertText(string user)
        {
            return "Foo2";
        }

        private string GetBlindsAlertText(long smallBlind, long bigBlind)
        {
            return "Foo3";
        }
    }
}
