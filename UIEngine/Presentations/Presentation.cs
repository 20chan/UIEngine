using System;
using System.Collections.Generic;
using System.Linq;

namespace UIEngine.Presentations
{
    public class Presentation
    {
        public List<Slide> Slides { get; private set; }
        public Slide CurrentSlide { get { return Slides[_current]; } }

        private int _current = 0;

        public Presentation()
        {
            Slides = new List<Slide>();
        }

        public void Begin()
        {
            CurrentSlide.SlideBegin();
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
                    throw new NotImplementedException();
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
