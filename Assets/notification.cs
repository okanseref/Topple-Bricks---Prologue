using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class notification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationChannel c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Keep Toppling";
        notification.SmallIcon = "icon_2";
        notification.LargeIcon = "icon_1";

        int x = Random.Range(0,3);
        switch (x)
        {
            case 0:
                notification.Text = "You have more levels to complete";
                break;
            case 1:
                notification.Text = "Lets push some bricks";
                break;
            case 2:
                notification.Text = "Come on test your cannon skills";
                break;
            default:
                notification.Text = "Lets push some bricks";
                break;
        }
        notification.Text = "You have more levels to complete";
        notification.FireTime = System.DateTime.Now.AddMinutes(1080);

        AndroidNotificationCenter.CancelAllNotifications();
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
