using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelDatabase
{
    enum Levels
    {
        Starry_Atoll_Zone = 4,
        Cyan_Canyon_Zone_1 = 5, 
        Cyan_Canyon_Zone_2 = 6,
        Virtua_Zone = 7,
        Celestial_Dunes_Zone_1 = 8,
        Celestial_Dunes_Zone_2 = 9,
        Lost_Ruins_Zone = 10,
        Jade_Forest_Zone = 11,
        Prismic_Factory_Zone = 12,
        Rockopolis_Zone = 13,
        Steaming_Bayou_Zone = 14,
        Distortion_Zone = 15
    }

    public static string Level(int SceneNumber)
    {
      return SceneNumber == 4  ? "Starry Atoll Zone"      : 
            (SceneNumber == 5  ? "Cyan Canyon Zone 1"     : 
            (SceneNumber == 6  ? "Cyan Canyon Zone 2"     : 
            (SceneNumber == 7  ? "Virtua Zone"            :
            (SceneNumber == 8  ? "Celestial Dunes Zone 1" :
            (SceneNumber == 9  ? "Celestial Dunes Zone 2" :
            (SceneNumber == 10 ? "Lost Ruins Zone"        :
            (SceneNumber == 11 ? "Jade Forest Zone"       :
            (SceneNumber == 12 ? "Prismic Factory Zone"   :
            (SceneNumber == 13 ? "Rockopolis Zone"        :
            (SceneNumber == 14 ? "Steaming Bayou Zone"    :
            (SceneNumber == 15 ? "Distortion Zone"        : 
            (SceneNumber == 3  ? "The funny haha"         : 
            "Illegal Instruction"))))))))))));
    }

    public static string LevelCaps(int SceneNumber)
    {
        return SceneNumber == 4 ? "STARRY ATOLL ZONE" :
              (SceneNumber == 5 ? "CYAN CANYON ZONE 1" :
              (SceneNumber == 6 ? "CYAN CANYON ZONE 2" :
              (SceneNumber == 7 ? "VIRTUA ZONE" :
              (SceneNumber == 8 ? "CELESTIAL DUNES ZONE 1" :
              (SceneNumber == 9 ? "CELESTIAL DUNES ZONE 2" :
              (SceneNumber == 10 ? "LOST RUINS ZONE" :
              (SceneNumber == 11 ? "JADE FOREST ZONE" :
              (SceneNumber == 12 ? "PRISMIC FACTORY ZONE" :
              (SceneNumber == 13 ? "ROCKOPOLIS ZONE" :
              (SceneNumber == 14 ? "STEAMING BAYOU ZONE" :
              (SceneNumber == 15 ? "DISTORTION ZONE" :
              (SceneNumber == 3 ? "THE FUNNY HAHA" :
              "ILLEGAL INSTRUCTION"))))))))))));
    }
}
