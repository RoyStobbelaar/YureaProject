using RpgLibrary.ConversationClasses;
using RpgLibrary.QuestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRpgLibrary.SpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.CharacterClasses;

namespace XRpgLibrary.CharacterClasses
{
    public class NonPlayerCharacter : Character
    {
        #region Fields & Properties Region

        readonly List<Conversation> conversations;
        readonly List<Quest> quests;

        public List<Conversation> Conversations
        {
            get { return conversations; }
        }

        public List<Quest> Quests
        {
            get { return quests; }
        }

        public bool HasConversation
        {
            get { return (conversations.Count > 0); }
        }

        public bool HasQuest
        {
            get { return (quests.Count > 0); }
        }

        #endregion

        #region Constructor Region

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
            conversations = new List<Conversation>();
            quests = new List<Quest>();
        }

        #endregion

        #region Methods Region

        #endregion

        #region Virtual Methods region

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        #endregion

    }
}
