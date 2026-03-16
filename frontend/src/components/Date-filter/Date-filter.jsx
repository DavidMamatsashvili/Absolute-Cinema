import { useRef, useState } from "react";

const DateFilter = () => {
    // console.log("component render");
    const [selectedDate, setSelectedDate] = useState(null);
    const sliderRef = useRef(null);
    const [persent, setPersent] = useState(0);
    // console.log(selectedDate)
    const today = new Date();
    const dates = [];

    for (let i = 0; i < 31; i++) {
        const eachDay = new Date(today);
        eachDay.setDate(today.getDate() + i);
        dates.push(eachDay);
    }

    const result = dates.map((date, index) => {
        const prev = dates[index - 1];
        const showMonth = index === 0 || date.getMonth() !== prev.getMonth();

        return {
            date,
            showMonth,
        };
    })


    const scroll = (direction) => {
        const container = sliderRef.current;
        const amount = 200;
        const maxScroll = container.scrollWidth - container.clientWidth;
        const percent = (container.scrollLeft / maxScroll) * 100;

        console.log('precent', percent);
        console.log('scrollLeft', container.scrollLeft);
        console.log('scrollWidth', container.scrollWidth);
        console.log('clientWidth', container.clientWidth);

        container.scrollBy({
            left: direction === "left" ? -amount : amount,
            behavior: "smooth",
        });
    };

    const handleScroll = () => {
        const el = sliderRef.current;
        const max = el.scrollWidth - el.clientWidth;
        const percent = (el.scrollLeft / max) * 100;
        setPersent(percent);
    };
    
    const isSameDay = (d1, d2) => d1.getFullYear() === d2.getFullYear() && d1.getMonth() === d2.getMonth() && d1.getDate() === d2.getDate();
    // console.log(result);

    return (
        <div className="date-slider">
            <div className="date-left-arrow" onClick={() => scroll("left")} style={{ opacity: persent === 0 ? ".6" : "1", cursor:  persent === 0 ? "not-allowed" : "pointer" }}>
                <p>{'<'}</p>
            </div>
            <div className="dates" ref={sliderRef} onScroll={handleScroll}>
                {result.map(date => {
                    const weekday = date.date.toLocaleString("en", { weekday: "short" });
                    const isSelected = selectedDate && isSameDay(selectedDate, date.date);
                    return (
                        <div className="each-day" key={date.date.toISOString()}>
                            {date.showMonth && (
                                <div className="month-label" style={{ color: "rgb(231 231 231)", }}>
                                    {date.date.toLocaleString("en", { month: "long" })}
                                </div>
                            )}
                            <label className={`day ${isSelected
                                ? "selected"
                                : ""
                                }`}>
                                <input
                                    type="radio"
                                    name="selectedDate"
                                    checked={selectedDate?.getTime() === date.date.getTime()}
                                    onChange={() => setSelectedDate((prev) => (prev?.getDay() === date?.date.getDay() && prev?.getMonth() === date?.date.getMonth()) ? null : date.date)}
                                />
                                <span className="week-day" style={
                                    {
                                        color: (weekday === "Sun" || weekday === "Sat") ? 'red' : "#A0A0A0",
                                    }
                                }>
                                    {(date.date.getDay() === today.getDay() && date.date.getMonth() === today.getMonth()) ? "Today" : `${weekday}`}
                                </span>
                                <span className="day-number" style={{ color: "white" }}>{date.date.getDate()}</span>
                            </label>
                        </div>
                    )
                })
                }
            </div>
            <div className="date-right-arrow" onClick={() => scroll('right')} style={{ opacity: persent === 100 ? ".6" : "1", cursor:  persent === 100 ? "not-allowed" : "pointer"}}>
                <p>{'>'}</p>
            </div>
        </div >
    )
}

export default DateFilter;