namespace HoleElevation.Abstractions
{
    /// <summary>
    /// Интерфейс который наследует окно, для возможности закрытия
    /// </summary>
    public interface IClosable
    {
        /// <summary>
        /// Закрыть окно
        /// </summary>
        public void Close();

        /// <summary>
        /// Прячет окно
        /// </summary>
        public void Hide();
    }
}