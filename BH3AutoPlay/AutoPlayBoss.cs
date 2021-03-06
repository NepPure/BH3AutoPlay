﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BH3AutoPlay
{
    class AutoPlayScript : AutoPlay
    {
        public String name;
        public String description;
        public String videoUrl;
        public DateTime startTime;
        public bool running = false;
        private Thread autoPlayThread;
        private Thread checkThread;
        public BH3Window bh3window;

        public AutoPlayScript(BH3Window bh3window)
        {
            this.bh3window = bh3window;

        }

        public void Restart()
        {
            Restart(bh3window.restartBtnPos1, bh3window.restartBtnPos2);
            Thread.Sleep(2000);
            Stop();
            Start();
        }

        public void Stop()
        {

            running = false;
            if (autoPlayThread != null)
            {

                autoPlayThread.Abort();
            }
            if (checkThread != null)
            {

                checkThread.Abort();
            }

        }

        public void Start()
        {
            running = true;
            startTime = DateTime.Now;
            autoPlayThread = new Thread(new ThreadStart(
                () =>
                {
                    Delay(200);
                    Action();
                }
            ));
            checkThread = new Thread(new ThreadStart(
                () =>
                {
                    while (running)
                    {

                        TimeSpan runingTime = DateTime.Now - this.startTime;
                        double runningSecond = runingTime.TotalSeconds;
                        OnCheckTime(runningSecond);
                        Thread.Sleep(100);
                    }
                }
            ));
            checkThread.Start();

            autoPlayThread.Start();
        }

        protected virtual void OnCheckTime(double runningSecond)
        {

        }

        public virtual void Action()
        {

        }

    }
    class AutoPlay山粉蓝vs月轮37760非up31146 : AutoPlayScript
    {
        public AutoPlay山粉蓝vs月轮37760非up31146(BH3Window bh3window) : base(bh3window)
        {
            name = "山粉蓝vs月轮37760(非up31146)";
            description = @"
1p 山吹 超限百手 毕毕牛（无元素词缀）
2p 蓝毛 重剑王蛇 古古牛
3P 粉毛 睡美人 卡卡米（有元素词缀，面板1343）
";
            videoUrl = "https://www.bilibili.com/video/BV1mZ4y1W7Ez";
        }


        protected override void OnCheckTime(double runningSecond)
        {
            if (runningSecond > 25)
            {
                Restart();
            }
            else if (22 > runningSecond && runningSecond > 19)
            {
                if (bh3window.CheckBossAlive())
                {
                    Restart();
                }
            }
            else if (12 > runningSecond && runningSecond > 10)
            {
                if (!bh3window.ShieldIsDestroy())
                {
                    Restart();
                }
            }
            if (15 > runningSecond && runningSecond > 13)
            {
                Keypress("u");
            }

        }

        public override void Action()
        {
            // 1p 山吹，2p 蓝毛，3p 粉毛
            // 山吹往前走一秒
            Keydown("w");
            Delay(700);

            Keydown("j");
            Delay(1300);
            Keyup("j");
            //KeydownThenUp("k", 300);
            Delay(200);
            //蓄力0.7秒
            Keydown("j");
            Delay(1600);
            Keyup("j");
            Delay(450);
            Keypress("j");
            Delay(600);
            Keyup("w");
            //盾反
            KeydownThenUp("k", 300);
            Delay(500);
            // 平A两下
            Keypress("j");
            Delay(300);
            // 人偶
            Keypress("l");
            Delay(200);
            Keypress("j");
            Delay(600);

            // 武器主动
            Keypress("u");
            Delay(1000);

            // 切蓝毛武器主动
            Keypress("1");
            Delay(300);
            Keypress("u");
            Delay(700);

            // 切粉毛
            Keypress("1");
            Delay(200);
            KeydownThenUp("j", 5500);
            Delay(200);
            Keypress("j");
            Delay(1100);
            Keypress("k");
            Delay(250);
            KeydownThenUp("j", 850);
            Delay(200);
            Keypress("j");
        }
    }

    class AutoPlay律山紫vs皮皮马31626up37952 : AutoPlayScript
    {

        public AutoPlay律山紫vs皮皮马31626up37952(BH3Window bh3window) : base(bh3window)
        {
            name = "律山紫vs皮皮马31626(up37952)";
            videoUrl = "https://www.bilibili.com/video/BV1JV411d7KW";
            description = @"
1p: 女王 灵枪八重 特贝牛
2p: 山吹 超限百手 毕毕牛
3p: 3s紫苑 极夜 猫卡卡
人偶仿犹大
";
        }

        private void 连续平A(int count)
        {
            int tmp = 0;
            while (tmp < count)
            {
                Keypress("j");
                Delay(150);
                tmp += 1;
            }

        }

        public override void Action()
        {
            // 女王往前闪避
            Keydown("w");
            Keypress("k");
            Delay(300);
            Keyup("w");

            // 切紫苑放十字架
            Keypress("2");
            Delay(200);
            Keydown("d");
            Keypress("u");
            Keyup("d");
            Delay(200);

            // A三下后闪避
            Keydown("w");
            连续平A(14);
            Keyup("w");

            Keypress("k");
            Delay(1000);
            Keypress("j");
            Delay(500);
            Keypress("j");
            Delay(500);

            // 切山吹
            Keypress("1");
            Delay(800);
            Keypress("j");
            Delay(700);

            // 盾反
            KeydownThenUp("k", 400);
            Delay(700);
            // A两下放武器
            Keypress("j");
            Delay(1300);
            Keypress("j");
            Keypress("l");
            Delay(200);
            Keypress("u");
            Delay(300);
            // 切女王qte
            Keypress("1");
            Delay(1600);
            // 女王闪避控住皮皮马
            Keydown("a");
            Keypress("k");
            Delay(600);
            Keyup("a");

            // 切紫苑qte
            Keypress("1");
            Delay(400);
            KeydownThenUp("j", 1000);  // 蓄力进入沸血状态

            连续平A(27);
            Delay(200);

            KeydownThenUp("j", 2000);  // 蓄力一击结束游戏

        }

        protected override void OnCheckTime(double runningSecond)
        {
            if (25 > runningSecond && runningSecond > 24)
            {
                if (bh3window.CheckBossAlive())
                {
                    Restart();
                }
            }
            else if (16 > runningSecond && runningSecond >= 15.5) { 
                // 判断第一波蓄力是否真猫
                if (bh3window.CheckColor(bh3window.healthPos, bh3window.HEALTH_COLOR_PURPLE))
                {
                    Restart();
                }
            }
        }
    }

}


