using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Outgame
{
    public class SummerEventView : UIStackableView
    {
        protected override void AwakeCall()
        {
            ViewId = ViewID.SummerEventTittle;
            _hasPopUI = false;
        }
        public void GoHome()
        {
            UIManager.NextView(ViewID.Home);
        }
    }
}
