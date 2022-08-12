/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: false,
  swcMinify: true,
  images: {
    domains: ["s100.divarcdn.com", "logo.samandehi.ir"],
  },
};

module.exports = nextConfig;
