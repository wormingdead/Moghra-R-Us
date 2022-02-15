using ConsoleLib.Console;
using System;
using System.Collections.Generic;
using XRL.Rules;
using XRL.UI;
using XRL.Wish;
using XRL.World;
using Mods.Wormingdead.MoghraRUs.JangleSnap;


namespace Mods.Wormingdead.MoghraRUs.JangleSnap.Game
{
  public enum Position
  {
    Loss,
    Win,
    Wanderer,
    Merchant,
    Pilgrim,
    Ascendant,
  }

  public class GameState
  {
    public GameObject Creature { get; }
    public Dice.Die[] DieHand { get; }
    public Position Position { get; }
    private GameState Opponent;

    private GameState(GameObject creature, Dice.DieKind dieKind)
    {
      Creature = creature;
      DieHand = Dice.createHand(dieKind);
      Position = Position.Wanderer;
    }

    public GameState(
      GameObject playerCreature,
      GameObject opponentCreature,
      Dice.DieKind dieKind = Dice.DieKind.Foraging
    ) : this(playerCreature, dieKind)
    {
      Opponent = new GameState(opponentCreature, Dice.Invert(dieKind), this);
    }

    private GameState(
      GameObject opponentCreature,
      Dice.DieKind dieKind,
      GameState gameState
    ) : this(opponentCreature, dieKind)
    {
      Opponent = gameState;
    }

    public static GameState Rotate(GameState gameState) => gameState.Opponent;


  }
}