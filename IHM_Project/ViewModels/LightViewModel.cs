﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IHM_Project.Model;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IHM_Project.ViewModels
{
    [ObservableObject]
    public partial class LightViewModel
    {

        int tick = 0;

        DispatcherTimer timerBlink = new DispatcherTimer();

        [ObservableProperty]
        private Bulb bulb1 = new();

        [ObservableProperty]
        private Bulb bulb2 = new();

        [ObservableProperty]
        private Bulb bulb3 = new();

        [ObservableProperty]
        private Bulb bulb4 = new();

        [ObservableProperty]
        private Bulb bulb5 = new();

        [ObservableProperty]
        private Bulb bulb6 = new();

        [ObservableProperty]
        private List<Bulb> bulbs = new();

        public IRelayCommand AnimationBlinkCommand { get; }

        public IRelayCommand AnimationFadeCommand { get; }
        public IRelayCommand AnimationMergeCommand { get; }
        public IRelayCommand AnimationF1Command { get; }

        public LightViewModel()
        {
            timerBlink.Tick += new EventHandler<object>(UpdateTimerBlink_Tick);
            timerBlink.Interval = new TimeSpan(0, 0, 0, 0, 500);

            AnimationBlinkCommand = new RelayCommand(AnimationBlink);
            AnimationFadeCommand = new RelayCommand(AnimationFade);
            AnimationMergeCommand = new RelayCommand(AnimationMerge);
            AnimationF1Command = new RelayCommand(AnimationF1);

            bulbs.Add(bulb1);
            bulbs.Add(bulb2);
            bulbs.Add(bulb3);
            bulbs.Add(bulb4);
            bulbs.Add(bulb5);
            bulbs.Add(bulb6);
            for (int i = 0; i < bulbs.Count; i++)
            {
                bulbs[i].Color = new SolidColorBrush(Colors.Gray);
            }
        }

        private void AnimationBlink()
        {
            this.tick = 0;

            timerBlink.Start();

        }

        private void AnimationFade()
        {
            for (int i = 0; i < bulbs.Count; i++)
            {
                bulbs[i].Color = new SolidColorBrush(Colors.Orange);
            }

        }


        private void AnimationMerge()
        {
            for (int i = 0; i < bulbs.Count; i++)
            {
                bulbs[i].Color = new SolidColorBrush(Colors.Green);
            }

        }

        private void AnimationF1()
        {
            for (int i = 0; i < bulbs.Count; i++)
            {
                bulbs[i].Color = new SolidColorBrush(Colors.Red);
            }

        }

        private void UpdateTimerBlink_Tick(object sender, object e)
        {

            tick = tick + 1;
            if (tick <= 8)
            {
                if (tick % 2 != 0)
                {
                    for (int i = 0; i < bulbs.Count; i++)
                    {
                        bulbs[i].Color = new SolidColorBrush(Colors.Blue);
                    }

                }

                if (tick % 2 == 0)
                {
                    for (int i = 0; i < bulbs.Count; i++)
                    {
                        bulbs[i].Color = new SolidColorBrush(Colors.Gray);
                    }

                }
            }
            else return;


            //while (animationCounter < 5)
            //{
            //    AnimationBlink();
            //    animationCounter++;
            //}
            //animationCounter = 0;
        }

    }
}
