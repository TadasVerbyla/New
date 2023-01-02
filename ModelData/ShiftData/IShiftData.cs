using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ShiftData
{
    public interface IShiftData
    {
        List<Shift> GetShifts();
        Shift GetShift(Guid id);
        Shift AddShift(ShiftDTO shift);
        void DeleteShift(Guid id);
        Shift EditShift(Guid id, ShiftDTO shift);
        Shift PatchShift(Guid id, ShiftDTO shift);
    }
}
