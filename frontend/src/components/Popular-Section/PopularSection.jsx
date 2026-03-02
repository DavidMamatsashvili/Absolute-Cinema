import { Swiper, SwiperSlide } from "swiper/react";
import { Pagination } from "swiper/modules";
import "swiper/css";
import "swiper/css/pagination";
import './PopularSection.css'

export default function PopularSection() {

    const data = [
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/b5c978f6-e595-422d-a94c-676c9879cf7a.jpeg', alt:'ზოოტოპია 2'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/9861e5d0-401b-4d9f-8417-4d4f0a3c1612.jpeg', alt:'ავატარი: ცეცხლი და ფერფლი'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/b3fd337c-4de1-4504-a3e2-06b664db8ae9.jpeg',alt:'ქარიშხლიანი უღელტეხილი'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/625c0bf0-6acc-4f88-b023-7a028f9053c3.jpeg',alt:'მოახლე'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/173641f2-c2e8-4322-b87e-a5ff2a5704d6.jpeg',alt:'ანაკონდა'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/804b8544-8e35-4d79-aaf3-ac5db58c91b4.jpeg',alt:'ლირიკა'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/773e1d1f-dedd-4379-946d-c9cf94d27bf1.jpeg',alt:'მარტი დიდებული'},
        {imgSrc: 'https://image.tkt.ge/unsafe/rs:fit:3840:/format:jpeg/plain/https://static.tkt.ge/img/dd8ad1e3-e103-4929-a3bf-29aa640350e7.jpeg',alt:'ჰამნეტი'}
    ]


    return (
        <section style={{paddingTop:"16px",paddingBottom:"20px"}} className="w-full">
            <div className="w-full flex items-center justify-center">
                <Swiper
                    modules={[Pagination]}
                    pagination={{ clickable: true }}
                    loop={true}
                    centeredSlides={true}
                    spaceBetween={16}
                    breakpoints={{
                        0: { slidesPerView: 1 },
                        1137.5: { slidesPerView: 2.5 },
                    }}
                    observer={true}
                    observeParents={true}
                    className=" h-full w-full [&_.swiper-pagination-bullet-active]:w-3.5 [&_.swiper-pagination]:flex [&_.swiper-pagination]:justify-center [&_.swiper-slide-active]:!scale-90 min-[1024px]:[&_.swiper-slide]:opacity-50 min-[1024px]:[&_.swiper-slide-active]:!opacity-100 [&_.swiper-slide-active+.swiper-slide+.swiper-slide+.swiper-slide]:scale-90 [&_.swiper-slide-active+.swiper-slide+.swiper-slide+.swiper-slide]:opacity-50 [&_.swiper-slide-active+.swiper-slide+.swiper-slide]:z-[-1] swiper-backface-hidden !pb-4 lg:rounded-2xl lg:!pb-4 "
                >

                    {data.map((item, index) => (
                    <SwiperSlide
                        key={index}
                        className="flex justify-center items-center w-">
                        <Section imgSrc={item.imgSrc} alt={item.alt} />
                    </SwiperSlide>
                    ))}

                </Swiper>
            </div>
        </section>
    );
}

export function Section({ imgSrc,alt }) {
    return (
        <div style={{margin:"auto",backgroundImage: `url(${imgSrc})`, backgroundSize: "cover", backgroundPosition: "center", backgroundRepeat: "no-repeat",}} className="transition-all duration-200 aspect-[1800/1200] w-full rounded-2xl relative">
            <div style={{padding:'8px'}} className='transition-all duration-200 absolute left-3 top-3 z-10 flex items-center justify-center gap-2 rounded-xl border backdrop-blur-[2px] border-white/10 bg-black/75 p-2 lg:left-4 lg:top-4 lg:p-2 scale-100 opacity-100'>
                <img alt={alt} src={`https://image.tkt.ge/unsafe/rs:fit:48:/format:svg/plain/https://static.tkt.ge/next/static/svg/cinema/popular-icon.svg`} />
                <span className='text-[0.625rem] text-white lg:text-xs '>Popular</span>
            </div>
        </div>
    )
}
