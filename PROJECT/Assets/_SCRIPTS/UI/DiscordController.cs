using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        /// GET CURRENT TIME
        var epochNow = (Int64)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        discord = new Discord.Discord(943728662769971241, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Debug Menu",
            Details = "Debug Menu",
            Timestamps =
            {
                Start = epochNow,
            },
            Assets = 
            {
               LargeImage = "icon",
            },
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.LogError("Connected to Discord!");
            }
        });
    }

    void Update ()
    {
        discord.RunCallbacks();
    }
    
}