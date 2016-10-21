using System;
using System.Collections.Generic;
using System.Linq;

namespace UIEngine.Presentations
{
    public class Presentation
    {
        public List<Slide> Slides { get; private set; }
        public Slide CurrentSlide { get { return Slides[_current]; } }

        public event Action PresentationEnded;
        public event Action InvalidateNeeded;

        private int _current = 0;

        public Presentation()
        {
            Slides = new List<Slide>();
        }

        private void InitEvent()
        {
            foreach (var s in Slides)
                s.InvalidateNeeded += () => InvalidateNeeded?.Invoke();
        }

        public void Begin()
        {
            InitEvent();
            CurrentSlide.SlideBegin();
        }

        public void Draw(System.Drawing.Graphics g, int width, int height)
        {
            CurrentSlide.Draw(g, width, height);
        }

        private void NextSlide()
        {
            _current++;
            CurrentSlide.SlideBegin();
        }

        public void Next()
        {
            //슬라이드의 모든 애니메이션이 재생되었다면 다음 슬라이드
            if (CurrentSlide.IsAllAnimationsPlayed)
            {
                if (Slides.Last() == CurrentSlide) //마지막 검은 화면
                    PresentationEnded?.Invoke();
                else
                    NextSlide();
            }
            else
                CurrentSlide.PlayAnimation();
        }

        public void Prev()
        {
            throw new NotImplementedException();
        }
    }
}
