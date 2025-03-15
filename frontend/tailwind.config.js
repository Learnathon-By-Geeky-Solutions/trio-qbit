/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#25255F",
        secondary: "#4057A7",
        lightSteelBlue: "#89B6E1",
        royalSteelBlue: "#44ACE1",
        black: "#000000",
        white:"#ffffff",
      }
    },
  },
  plugins: [
    require('daisyui'),
  ],
}

