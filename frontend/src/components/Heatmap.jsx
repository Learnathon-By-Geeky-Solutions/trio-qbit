import './Heatmap.css';

const Heatmap = () => {
  // Define expanded demo data with explicit January entries
  const demoData = [
    // January 2024 (31 days) - Added more explicit entries
    { date: '2024-01-01', count: 5, streak: 1 }, // Sunday
    { date: '2024-01-02', count: 3, streak: 2 }, // Monday
    { date: '2024-01-03', count: 2, streak: 3 }, // Tuesday
    { date: '2024-01-05', count: 4, streak: 5 }, // Thursday
    { date: '2024-01-10', count: 3, streak: 10 }, // Tuesday
    { date: '2024-01-15', count: 6, streak: 15 }, // Sunday
    { date: '2024-01-20', count: 2, streak: 20 }, // Friday
    { date: '2024-01-25', count: 5, streak: 25 }, // Wednesday
    { date: '2024-01-31', count: 4, streak: 31 }, // Tuesday
    // February 2024 (29 days, leap year)
    { date: '2024-02-01', count: 3, streak: 32 },
    { date: '2024-02-15', count: 4, streak: 46 },
    { date: '2024-02-29', count: 2, streak: 60 },
    // March 2024 (31 days)
    { date: '2024-03-10', count: 6, streak: 70 },
    { date: '2024-03-20', count: 3, streak: 80 },
    // April 2024 (30 days)
    { date: '2024-04-05', count: 5, streak: 85 },
    { date: '2024-04-15', count: 2, streak: 95 },
    // May 2024 (31 days)
    { date: '2024-05-01', count: 4, streak: 100 },
    { date: '2024-05-15', count: 6, streak: 115 },
    { date: '2024-05-31', count: 3, streak: 131 },
    // June 2024 (30 days)
    { date: '2024-06-10', count: 5, streak: 136 },
    { date: '2024-06-20', count: 2, streak: 146 },
    // July 2024 (31 days)
    { date: '2024-07-01', count: 4, streak: 151 },
    { date: '2024-07-15', count: 6, streak: 165 },
    { date: '2024-07-31', count: 3, streak: 181 },
    // August 2024 (31 days)
    { date: '2024-08-10', count: 5, streak: 186 },
    { date: '2024-08-20', count: 2, streak: 196 },
    // September 2024 (30 days)
    { date: '2024-09-01', count: 4, streak: 201 },
    { date: '2024-09-15', count: 6, streak: 215 },
    // October 2024 (31 days)
    { date: '2024-10-05', count: 3, streak: 220 },
    { date: '2024-10-15', count: 5, streak: 230 },
    { date: '2024-10-31', count: 2, streak: 246 },
    // November 2024 (30 days)
    { date: '2024-11-10', count: 4, streak: 251 },
    { date: '2024-11-20', count: 6, streak: 261 },
    // December 2024 (31 days)
    { date: '2024-12-01', count: 3, streak: 266 },
    { date: '2024-12-15', count: 5, streak: 280 },
    { date: '2024-12-31', count: 2, streak: 296 },
    // January 2025 (31 days)
    { date: '2025-01-05', count: 4, streak: 301 },
    { date: '2025-01-15', count: 6, streak: 311 },
    // February 2025 (28 days)
    { date: '2025-02-01', count: 3, streak: 316 },
    { date: '2025-02-15', count: 5, streak: 330 },
    // March 2025 (31 days, up to 6th)
    { date: '2025-03-01', count: 4, streak: 335 },
    { date: '2025-03-02', count: 3, streak: 336 },
    { date: '2025-03-03', count: 5, streak: 337 },
    { date: '2025-03-04', count: 2, streak: 338 },
    { date: '2025-03-05', count: 6, streak: 339 },
    { date: '2025-03-06', count: 3, streak: 340 }, // Current date
  ];

  // Sample color scale function (light blue to dark blue)
  const getColor = (count) => {
    const maxProblems = Math.max(...demoData.map((d) => d.count), 1); // Avoid division by zero
    const intensity = Math.min(count / maxProblems, 1); // Normalize to [0, 1]
    const blueValue = Math.round(139 - intensity * 139); // From #ADD8E6 (light blue) to #00008B (dark blue)
    return `rgb(0, 0, ${blueValue})`;
  };

  // Generate a 2D array for the heatmap (12 months x 7 days)
  const getHeatmapData = () => {
    const heatmap = Array(12).fill().map(() => Array(7).fill(null)); // 12 months x 7 days
    const startDate = new Date(2024, 0, 1); // January 1, 2024
    const endDate = new Date(2025, 2, 6); // March 6, 2025
    demoData.forEach((item) => {
      const date = new Date(item.date);
      if (date >= startDate && date <= endDate) {
        const month = date.getMonth(); // 0-11 for January-December
        const day = date.getDay(); // 0-6 for Sunday-Saturday
        if (month >= 0 && month < 12 && day >= 0 && day < 7) {
          heatmap[month][day] = (heatmap[month][day] || 0) + (item.count || 0);
        }
      }
    });
    return heatmap;
  };

  const heatmapData = getHeatmapData();

  // Labels for months and days
  const months = [
    'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
    'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'
  ];
  const days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

  return (
    <div className="heatmap-container">
      {/* <div className="heatmap-header">
        <span>Only public activity</span>
        <select>
          <option>Only public</option>
        </select>
        <select>
          <option>Choose year</option>
        </select>
      </div> */}
      <div className="heatmap">
        <div className="heatmap-labels">
          {days.map((day, index) => (
            <div key={index} className="day-label">{day.slice(0, 1)}</div>
          ))}
        </div>
        <div className="heatmap-grid">
          {heatmapData.map((week, monthIndex) =>
            week.map((count, dayIndex) => (
              <div
                key={`${monthIndex}-${dayIndex}`}
                className="heatmap-cell"
                style={{
                  backgroundColor: count ? getColor(count) : '#4a4a4a',
                  opacity: count ? 1 : 0.3,
                }}
                title={`Problems: ${count || 0}`}
              />
            ))
          )}
        </div>
        <div className="month-labels">
          {months.map((month, index) => (
            <div
              key={index}
              className="month-label"
              style={{ left: `${(index * 100) / 11}%` }} // 12 months, 11 intervals
            >
              {month}
            </div>
          ))}
        </div>
      </div>
      {/* <div className="heatmap-stats">
        <div>
          <span>{demoData.reduce((sum, d) => sum + (d.count || 0), 0)} problems</span>
          <span>solved for all time</span>
        </div>
        <div>
          <span>{demoData.filter(d => {
            const date = new Date(d.date);
            return date.getFullYear() === 2024;
          }).reduce((sum, d) => sum + (d.count || 0), 0)} problems</span>
          <span>solved for the last year</span>
        </div>
        <div>
          <span>{demoData.filter(d => {
            const date = new Date(d.date);
            const lastMonth = new Date(2025, 2, 1); // March 1, 2025
            return date >= lastMonth;
          }).reduce((sum, d) => sum + (d.count || 0), 0)} problems</span>
          <span>solved for the last month</span>
        </div>
        <div>
          <span>{Math.max(...demoData.map(d => d.streak || 0))} days</span>
          <span>in a row max.</span>
        </div>
      </div> */}
    </div>
  );
};

export default Heatmap;