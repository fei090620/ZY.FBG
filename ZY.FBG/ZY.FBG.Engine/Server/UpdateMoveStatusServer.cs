using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ZY.FBG.Engine.Sagas;

namespace ZY.FBG.Engine.Server
{
    public sealed class UpdateMoveStatusServer
    {
        public static readonly UpdateMoveStatusServer Instance = new UpdateMoveStatusServer();
        private List<string> _updateObjectIds;
        private UpdateMoveStatusServer()
        {
            _updateObjectIds = new List<string>();
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            if (!_updateObjectIds.Any()) return;
            lock (e)
            {
                _updateObjectIds.ForEach(x =>
                {
                    dynamic moveObject = Repository.Instance.GetById(x);
                    moveObject.Status.UpdatePos();
                    Repository.Instance.Update(moveObject);
                });
            }
        }

        public void Register(string moveObjectID)
        {
            if (string.IsNullOrEmpty(moveObjectID)
                || _updateObjectIds.Contains(moveObjectID)) return;
            _updateObjectIds.Add(moveObjectID);
        }
    }
}
