import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);
const data = [
  { name: "2017", react: 32, angular: 37, vue: 60 },
  { name: "2018", react: 42, angular: 42, vue: 54 },
  { name: "2019", react: 51, angular: 41, vue: 54 },
  { name: "2020", react: 60, angular: 37, vue: 28 },
  { name: "2021", react: 51, angular: 31, vue: 27 },
  { name: "2022", react: 95, angular: 44, vue: 49 },
];
const options={};
const labels = ["2017", "2018", "2019", "2020", "2021", "2022"];
const dataTwo = {
  labels,
  datasets: [
    {
      label: "React",
      data: [32, 42, 51, 60, 51, 95],
      backgroundColor: "#2196F3",
      borderColor: "#2196F3",
    },
    {
      label: "Angular",
      data: [37, 42, 41, 37, 31, 44],
      backgroundColor: "#F44236",
      borderColor: "#F44236",
    },
    {
      label: "Vue",
      data: [60, 54, 54, 28, 27, 49],
      backgroundColor: "#FFCA29",
      borderColor: "#FFCA29",
    },
  ],
};
const EtatParking = () => {
  return (
    <>
      <div style={{ width: 500, height: 300 }} >
        <Line options={options} data={dataTwo}></Line>
      </div>
      {/* <h1>EtatParking</h1> */}
    </>
  );
};
export default EtatParking;
