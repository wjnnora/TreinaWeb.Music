using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musica.Dominio;
using TreinaWeb.Musica.Web.ViewModels.Album;
using TreinaWeb.Musica.Web.ViewModels.Musica;

namespace TreinaWeb.Musica.Web.AutoMapper
{
    public class Map
    {
        public void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Album, AlbumExibicaoIndexViewModel>();
                cfg.CreateMap<Album, AlbumExibicaoIndexViewModel>()
                    .ForMember(p => p.Nome, odt => odt.MapFrom(src => string.Format("{0} ({1})", src.Nome, src.Ano)));
                    
                cfg.CreateMap<Album, AlbumViewModel>();
                cfg.CreateMap<AlbumViewModel, Album>();
                cfg.CreateMap<Dominio.Musica, MusicaViewModel>();
                cfg.CreateMap<MusicaViewModel, Dominio.Musica>();
                cfg.CreateMap<Dominio.Musica, MusicaExibicaoViewModel>()
                    .ForMember(p => p.NomeAlbum, opt =>
                    {
                        opt.MapFrom(src => src.Album.Nome);
                    });
            });
        }
    }
}