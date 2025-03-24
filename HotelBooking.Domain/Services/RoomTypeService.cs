using AutoMapper;
using HotelBooking.Core.Interfaces;
using HotelBooking.Core.Model;
using HotelBooking.Domain.DTOs.RequestDto;
using HotelBooking.Domain.DTOs.ResponseDto;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Domain.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IMapper mapper;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            this.roomTypeRepository = roomTypeRepository;
            this.mapper = mapper;
        }
 
        //iroomservice rogor ewereboda Tu mag interfeis aimpelmentireb
        //da qvevit imitom qmni imis obieqts ro miwvde repositoris funqciebs
        //ver gaige es nawili? aa ki ki gasagebia, roomtype controlerShi standartulad gavuwere xutive, rame gansakurtebulad xo ar undoda? araaa daaimpelemtire oghond ase ar datovo, es mqonia darchenili marto da axla vshvebi, aqac standartulad xutive xo ?  xoo da kide ro avpune is funqciac daamate da danarchens mere mkitxe da getyvi ra gaaketo
        //dajavshna shesacvlelia magaze ifiqre rogor unda qna, magalitad dges ro martia 21 da javshani aris 1 aprilidan
        //me xo unda shemedzlos 22 dan 1 mde kide erti javshani, es rato? imitom rom is veli isavaliable vafshe amosaghebia
        //furcelze chamowere da ideurad ifiqre ra ginda, okeeee es okeeee ici rogoria? imena swervebis ;dddd iasna

        //waved ert wams. anu wasashleli araa, prosta eg iyos veli romelic aghnishnavs otaxi prosta daijavshneba tu ara
        //xoda javshani sxvanairadaa gasaketeveku. shen ro dajavshno kachretus nomeri 1 aprilidan 3 mde.
        //me xo ici txa txaze naklebi da waval xvalidan 3 dghe momindeba javshani
       //axla rogorc gvaqvs ver davjavshni. dasamatebelia is ro tarighebi iyos gatvaliswinebulki. eg leqtorma rac miTxra xo
       //xo da ifiqre, furcelze dawere, da ideurad dawere yvekaeru rogor aris, kaiiii , midi  xan magdebs xan darchio
       //imenaaaaaa <33333333333333 kai tu ramea xazze var, bazashi shecdoma vipove me da imas gavasworeb, kai gogo xar <koala
        public async Task CreateRoomType(RoomTypeDTO roomType)
        {
            if(roomType == null)
            {
                throw new ArgumentNullException("RoomType Is Empty.");
            }
            var map = mapper.Map<RoomType>(roomType);
            await roomTypeRepository.CreateRoomType(map);
        }

        public async Task DeleteRoomType(int id)
        {
            if(id < 0)
            {
                throw new ArgumentException("Id Less Than 0.");
            }
            await roomTypeRepository.DeleteRoomType(id);
        }

        public async Task<IEnumerable<RoomTypeResponseDTO>> GetAllRoomType()
        {
            var result = await roomTypeRepository.GetAllRoomType();
            var map = mapper.Map<IEnumerable<RoomTypeResponseDTO>>(result);
            return map;
        }

        public async Task<RoomTypeResponseDTO> GetRoomTypeById(int id)
        {
            var result = await roomTypeRepository.GetRoomTypeById(id);
            var map = mapper.Map<RoomTypeResponseDTO>(result);
            return map;
        }

        public async Task UpdateRoomType(int id, RoomTypeDTO roomType)
        {
            var map = mapper.Map<RoomType>(roomType);
            await roomTypeRepository.UpdateRoomType(id, map);
        }
    }
}
