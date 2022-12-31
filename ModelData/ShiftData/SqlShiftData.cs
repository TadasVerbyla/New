using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.ShiftData
{
    public class SqlShiftData : IShiftData
    {
        private PointOfSaleContext context;
        public SqlShiftData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Shift AddShift(ShiftDTO shift)
        {
            Shift _shift = new Shift();
            _shift.endTime = shift.endTime;
            _shift.startTime = shift.startTime;
            _shift.workdays = shift.workdays;
            _shift.id = Guid.NewGuid();
            context.Shifts.Add(_shift);
            context.SaveChanges();
            return _shift;
        }

        public void DeleteShift(Guid id)
        {
            context.Shifts.Remove(GetShift(id));
            context.SaveChanges();
        }

        public Shift EditShift(Shift shift)
        {
            var existing = context.Shifts.Find(shift.id);
            existing.startTime = shift.startTime;
            existing.endTime = shift.endTime;
            existing.workdays = shift.workdays;
            context.Shifts.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Shift GetShift(Guid id)
        {
            return context.Shifts.Find(id);
        }

        public List<Shift> GetShifts()
        {
            return context.Shifts.ToList();
        }
    }
}
