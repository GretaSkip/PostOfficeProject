using PostOfficeBackend.Dtos;
using PostOfficeBackend.Entities;
using PostOfficeBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostOfficeBackend.Services
{
    public class ParcelService
    {
        private ParcelRepository _parcelRepository;
        public ParcelService(ParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<List<Parcel>> GetAllAsync() =>
            await _parcelRepository.GetAsync();


        public async Task<int> CreateAsync(ParcelCreateEditDto parcel)
        {
            var parcelEntity = new Parcel()
            {
                Id = parcel.Id,
                Recipient = parcel.Recipient,
                Weight = parcel.Weight,
                Phone = parcel.Phone,
                Info = parcel.Info,
                PostId = parcel.PostId
            };

            return await _parcelRepository.CreateAsync(parcelEntity);
        }

        public async Task<Parcel> GetByIdAsync(int id) =>
            await _parcelRepository.GetByIdAsync(id);


        public async Task<List<Parcel>> GetByPostIdAsync(int postId) =>
            await _parcelRepository.GetByPostIdAsync(postId);


        public async Task RemoveAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            await _parcelRepository.RemoveAsync(parcel);
        }

        public async Task UpdateAsync(ParcelCreateEditDto parcel)
        {
            var existingParcel = await _parcelRepository.GetByIdAsync(parcel.Id);
            if (existingParcel != null)
            {
                existingParcel.Recipient = parcel.Recipient;
                existingParcel.Weight = parcel.Weight;
                existingParcel.Phone = parcel.Phone;
                existingParcel.Info = parcel.Info;
                existingParcel.PostId = parcel.PostId;

            }
            await _parcelRepository.UpdateAsync(existingParcel);
        }
    }
}
