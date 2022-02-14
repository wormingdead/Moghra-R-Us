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
    public GameObject Creature;
    public Dice.Die[] DieHand;
    public Position Position;
    public GameState Opponent;

    public GameState(
      GameObject playerCreature,
      GameObject opponentCreature,
      Dice.DieKind dieKind = Dice.DieKind.Foraging)
    {
      Creature = playerCreature;
      DieHand = Dice.createHand(dieKind);
      Position = Position.Wanderer;
      Opponent = new GameState(
        opponentCreature,
        Dice.Invert(dieKind),
        this
      );
    }

    private GameState(
      GameObject opponentCreature,
      Dice.DieKind dieKind,
      GameState gameState)
    {
      Creature = opponentCreature;
      DieHand = Dice.createHand(dieKind);
      Position = Position.Wanderer;
      Opponent = gameState;
    }
  }

  public static GameState Rotate(GameState gameState) => gameState.Opponent;
}