using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIEngine.Presentations
{
    public class Presentation
    {
        public List<Slide> Slides { get; }
        public Slide CurrentSlide { get { return Slides[_current]; } }

        private int _current = 0;
        public void Next()
        {
            //슬라이드의 모든 애니메이션이 재생되었다면 다음 슬라이드
            if(CurrentSlide.IsAllAnimationsPlayed)
            {
                NextSlide();
            }
        }

        private void NextSlide()
        {

        }

        public void Prev()
        {

        }
    }
}
