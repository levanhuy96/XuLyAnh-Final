namespace XuLyAnhFinal
{
    /// <summary>
    /// Lớp khai báo các tham số phụ
    /// Phục vụ quá trình phân đoạn hình ảnh
    /// </summary>
    public class SegmentOptions
    {
        public double ThreshHold { get; set; }
        public int MinSize { get; set; }
    }
}