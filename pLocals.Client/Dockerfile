# syntax=docker.io/docker/dockerfile:1

# Stage 1: Dependencies
FROM node:18-alpine AS deps
WORKDIR /app

# Add necessary build tools
RUN apk add --no-cache libc6-compat python3 make g++

# Install dependencies
COPY package*.json ./
# Clean install dependencies with legacy peer deps
RUN npm ci --include=dev --legacy-peer-deps \
    || (rm -rf node_modules && npm install --legacy-peer-deps)

# Stage 2: Builder
FROM node:18-alpine AS builder
WORKDIR /app

# Copy dependencies from deps stage
COPY --from=deps /app/node_modules ./node_modules
COPY . .

# Build the Next.js application
ENV NEXT_TELEMETRY_DISABLED 1
RUN npm run build

# Stage 3: Runner
FROM node:18-alpine AS runner
WORKDIR /app

ENV NODE_ENV production
ENV NEXT_TELEMETRY_DISABLED 1

# Add necessary runtime dependencies
RUN apk add --no-cache libc6-compat

# Add non-root user for security
RUN addgroup --system --gid 1001 nodejs
RUN adduser --system --uid 1001 nextjs

# Copy necessary files from builder
COPY --from=builder /app/public ./public
COPY --from=builder /app/.next/standalone ./
COPY --from=builder /app/.next/static ./.next/static

# Set correct permissions
RUN chown -R nextjs:nodejs /app

# Switch to non-root user
USER nextjs

# Expose port
EXPOSE 3000

# Set hostname
ENV HOSTNAME "0.0.0.0"

# Start the application
CMD ["node", "server.js"]