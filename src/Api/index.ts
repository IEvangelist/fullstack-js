import express from 'express';

const app = express();
const port = process.env["PORT"] || 3000;

const summaries = [
  'Freezing', 'Bracing', 'Chilly', 'Cool', 'Mild',
  'Warm', 'Balmy', 'Hot', 'Sweltering', 'Scorching'
];

// Add weather forecast endpoint.
app.get('/weatherforecast', (_, res) => {
  const forecasts: WeatherForecasts = Array.from({ length: 5 }, (_, index) => {
    const date = new Date();
    date.setDate(date.getDate() + index + 1);

    const tempC = Math.floor(Math.random() * 75) - 20;
    const tempF = Math.floor(tempC * 9 / 5) + 32;
    const summaryIndex = Math.min(Math.max(Math.floor((tempC + 20) / 10), 0), summaries.length - 1);

    return {
      date: date.toISOString().split('T')[0],
      temperatureC: tempC,
      temperatureF: tempF,
      summary: summaries[summaryIndex]
    };
  });

  res.json(forecasts);
});

app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

type WeatherForecasts = WeatherForecast[];