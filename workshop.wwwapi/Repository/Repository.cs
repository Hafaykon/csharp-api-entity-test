﻿using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Patient> GetPatientrById(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Appointment> GetAppointmentById(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments
                .FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }
    }
}
