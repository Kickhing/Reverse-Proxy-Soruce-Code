using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FireSocks
{
    public class BPListView : ListView
    {
        private List<GlowEffect> _Glows;
        private IContainer components;

        public BPListView()
        {
            this.InitializeComponent();
            this.OwnerDraw = true;
            this.DoubleBuffered = true;
            this._Glows = new List<GlowEffect>();

            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += t_Tick;
            timer.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int num = 0;
            foreach (var glow in _Glows)
            {
                if (glow.Counter > 0)
                {
                    glow.Counter--;
                    if (glow.Counter == 0)
                        num++;
                }
            }

            if (num > 0)
                this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private GlowEffect GetGlowEffect(ListViewItem lvi)
        {
            var glowEffect = _Glows.Find(glow => glow.LVI == lvi);
            if (glowEffect == null)
            {
                glowEffect = new GlowEffect
                {
                    Counter = 0,
                    LVI = lvi
                };
                _Glows.Add(glowEffect);
            }
            return glowEffect;
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Rectangle rect = new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width - 8, e.Bounds.Height - 4);

                Brush brush = GetGlowEffect(e.Item).Counter > 0 ? Brushes.Green : Brushes.Red;
                e.Graphics.FillRectangle(brush, rect);
            }
            else
            {
                e.DrawDefault = true;
                base.OnDrawSubItem(e);
            }
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }

        public void RemoveItem(ListViewItem lvi)
        {
            var glow = _Glows.Find(g => g.LVI == lvi);
            if (glow != null)
            {
                _Glows.Remove(glow);
            }

            this.Items.Remove(lvi);
            this.Invalidate();
        }

        public void MarkUsage(ListViewItem lvi)
        {
            var glow = GetGlowEffect(lvi);
            glow.Counter = 20;
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        private class GlowEffect
        {
            public ListViewItem LVI { get; set; }
            public int Counter { get; set; }
        }
    }
}
