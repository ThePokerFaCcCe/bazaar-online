/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  swcMinify: true,
  images: {
    domains: ["s100.divarcdn.com", "logo.samandehi.ir"],
  },
};

module.exports = nextConfig;
