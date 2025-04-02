import express from 'express';

const app = express();
const port = process.env["PORT"] || 3000;

const summaries = [
  'Freezing', 'Bracing', 'Chilly', 'Cool', 'Mild',
  'Warm', 'Balmy', 'Hot', 'Sweltering', 'Scorching'
];

// Add weather forecast endpoint.


app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});

interface WeatherForecast {
  date: string;
  temperatureC: number;
  summary: string;
}

type WeatherForecasts = WeatherForecast[];