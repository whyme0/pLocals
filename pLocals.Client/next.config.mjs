/** @type {import('next').NextConfig} */
const nextConfig = {
  output: 'standalone',
  env: {
      NEXT_PUBLIC_API_FOR_CLIENT: "http://localhost:5187"
  }
};

export default nextConfig;
