namespace Threeuple
{
    class Threeuple <T1, T2, T3>
    {
        public T1 FirstItem { get; set; }

        public T2 SecondItem { get; set; }

        public T3 ThirdItem { get; set; }

        public Threeuple(T1 ifirstItem, T2 secondItem, T3 thirdItem)
        {
            FirstItem = ifirstItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
