namespace tupianwenziPlugin
{
    using GameGlobal;
    using GameObjects;
    using PluginInterface;
    using System;
    using System.Collections.Generic;
    using GameFreeText;

    internal class GameObjectAndBranchName
    {
        internal string branchName;
        internal GameObject gameObject;
        internal IConfirmationDialog iConfirmationDialog;
        internal GameDelegates.VoidFunction NoFunction;
        internal Person person;
        internal List<SimpleText> texts = new List<SimpleText>();
        internal GameDelegates.VoidFunction YesFunction;

        internal GameObjectAndBranchName(GameObject   p, GameObject g, List<SimpleText> list, string name, IConfirmationDialog confirmationDialog, GameDelegates.VoidFunction yesFunction, GameDelegates.VoidFunction noFunction)
        {
            this.person = p as Person ;
            this.gameObject = g;
            this.texts.AddRange(list);
            this.branchName = name;
            this.iConfirmationDialog = confirmationDialog;
            this.YesFunction = yesFunction;
            this.NoFunction = noFunction;
        }
    }
}

