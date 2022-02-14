using System;
using Mods.Wormingdead.MoghraRUs;


namespace Mods.Wormingdead.MoghraRUs.JangleSnap.Dice
{
  public enum DieSide
  {
    YoungIvory,
    Brinestalk,
    WaterDram,
    Tonic,
    Turret,
    MoghraYi,
    Shrine,
    Spindle,
  }

  public static readonly DieSide[] DieSidesForaging = new
  {
    DieSide.YoungIvory,
    DieSide.Brinestalk,
    DieSide.WaterDram,
    DieSide.Brinestalk,
    DieSide.WaterDram,
    DieSide.Tonic,
  };

  public static readonly DieSide[] DieSidesScavenging = new
  {
    DieSide.Turret,
    DieSide.MoghraYi,
    DieSide.Shrine,
    DieSide.Spindle,
  };

  public enum DieKind
  {
    Foraging,
    Scavenging,
  }

  public static DieKind Invert = dieKind => dieKind switch
  {
    DieKind.Foraging => DieKind.Scavenging,
    DieKind.Scavenging => DieKind.Foraging,
  };

  public class Die
  {
    private DieSide[] Sides;
    public DieKind Kind { get; }
    public DieSide? Value { get; }

    public Die(DieKind kind)
    {
      Kind = kind;
      Sides = kind switch
      {
        DieKind.Foraging => DieSidesForaging,
        DieKind.Scavenging => DieSidesScavenging,
      };
    }
  }

  public static Die[] createHand(DieKind dieKind) => new
  {
    new Die(dieKind),
    new Die(DieKind.Foraging)
  };
}