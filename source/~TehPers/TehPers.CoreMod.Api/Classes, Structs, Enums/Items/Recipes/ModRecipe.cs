﻿using System.Collections.Generic;
using System.Linq;
using TehPers.CoreMod.Api.ContentLoading;
using TehPers.CoreMod.Api.Drawing.Sprites;
using TehPers.CoreMod.Api.Extensions;

namespace TehPers.CoreMod.Api.Items.Recipes {
    public class ModRecipe : SimpleRecipe {
        private readonly ICoreTranslationHelper _translationHelper;
        private readonly string _name;

        public override IEnumerable<IRecipePart> Ingredients { get; }
        public override IEnumerable<IRecipePart> Results { get; }
        public override ISprite Sprite { get; }

        public ModRecipe(ICoreTranslationHelper translationHelper, ISprite sprite, IRecipePart result, params IRecipePart[] ingredients) : this(translationHelper, sprite, result.Yield(), ingredients?.AsEnumerable()) { }
        public ModRecipe(ICoreTranslationHelper translationHelper, ISprite sprite, IRecipePart result, IEnumerable<IRecipePart> ingredients, string name = null) : this(translationHelper, sprite, result.Yield(), ingredients?.AsEnumerable(), name) { }
        public ModRecipe(ICoreTranslationHelper translationHelper, ISprite sprite, IEnumerable<IRecipePart> results, params IRecipePart[] ingredients) : this(translationHelper, sprite, results, ingredients?.AsEnumerable()) { }
        public ModRecipe(ICoreTranslationHelper translationHelper, ISprite sprite, IEnumerable<IRecipePart> results, IEnumerable<IRecipePart> ingredients, string name = null) {
            this.Sprite = sprite;
            this.Results = results;
            this.Ingredients = ingredients;
            this._translationHelper = translationHelper;
            this._name = name;
        }

        public override string GetDisplayName() {
            return this._name == null ? base.GetDisplayName() : this._translationHelper.Get($"recipe.{this._name}").WithDefault(this._name).ToString();
        }

        public override string GetDescription() {
            return this._name == null ? base.GetDisplayName() : this._translationHelper.Get($"recipe.{this._name}.description").WithDefault(base.GetDescription()).ToString();
        }
    }
}