using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Outgame.QuestListView;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;

namespace Outgame
{
    public class SummerEventView : UIStackableView
    {
        [SerializeField] QuestListView _listView;
        protected override void AwakeCall()
        {
            ViewId = ViewID.SummerEventTittle;
            _hasPopUI = false;
        }
        private async void Start()
        {
            await QuestListModel.LoadAsync();

            _listView.Setup();
            _listView.SetReadyCallback(Ready);
            Active();
        }

        void Ready(int questId)
        {
            SequenceBridge.RegisterSequence("Quest", SequencePackage.Create<QuestPackage>(UniTask.RunOnThreadPool(async () =>
            {
                var start = await GameAPI.API.QuestStart(questId);
                //�{���̓C���Q�[���ɍs��
                //�������Ă��Ƃɂ���
                var result = await GameAPI.API.QuestResult(1);

                //�A�C�e���t�^


                //�p�b�P�[�W
                var package = SequenceBridge.GetSequencePackage<QuestPackage>("Quest");
                package.QuestResult = result;

                //���U���g��
                UniTask.Post(GoResult);
            })));
        }

        void GoResult()
        {
            UIManager.NextView(ViewID.QuestResult);
        }
        public void GoHome()
        {
            UIManager.NextView(ViewID.Home);
        }
        public void Back()
        {
            UIManager.Back();
        }
    }
}
